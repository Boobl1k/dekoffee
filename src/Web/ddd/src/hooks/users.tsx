import {useEffect,useState} from 'react'
import { IUser } from '../models'
import axios from 'axios'

export function useUsers() {
    async function fetchUsers() {
        try{
          setError('')
          setLoading(true)
          const response=await axios.get<IUser[]>('http://localhost:5000/admin/users')
          setUser(response.data)
          setLoading(false)
        }
        catch(e: unknown){
          const error=e as any
          setLoading(false)
          setError(error.message)
        }
      }
      
      function addUser(user:IUser){
        setUser(prev=>[...prev,user])
      }

      useEffect(()=>{
        fetchUsers()
      },[])
    
      const [users,setUser]=useState<IUser[]>([])
      const [loading,setLoading] =useState(false)
      const [error,setError]=useState('')

      return{users,error,loading,addUser}
}