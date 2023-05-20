import {useEffect,useState} from 'react'
import { IOrder } from '../models'
import axios from 'axios'

export function useOrders() {
    async function fetchOrders() {
        try{
          setError('')
          setLoading(true)
          const response=await axios.get<IOrder[]>('http://localhost:5000/admin/orders')
          setOrders(response.data)
          setLoading(false)
        }
        catch(e: unknown){
          const error=e as any
          setLoading(false)
          setError(error.message)
        }
      }
      
      function addOrder(order:IOrder){
        setOrders(prev=>[...prev,order])
      }

      useEffect(()=>{
        fetchOrders()
      },[])
    
      const [orders,setOrders]=useState<IOrder[]>([])
      const [loading,setLoading] =useState(false)
      const [error,setError]=useState('')

      return{orders,error,loading,addOrder}
}