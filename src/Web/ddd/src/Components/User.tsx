import axios from 'axios'
import React, {useState} from 'react'
import { IUser } from '../models'

interface UserProps{
    user:IUser
}

export function User({user}: UserProps){
    
    const [details, setDetails]= useState(false)

    const btnBgClassName=details?'bg-blue-400': 'bg-yellow-400'

    const btnClasses=['py-2 px-4 border',btnBgClassName]

    return (
        <div className="border py-2 px-4 rounded flex flex-col items-center mb-2">
            <p>{user.email}</p>
            <div className="flex justify-between">
            <button className={btnClasses.join(' ')} onClick={()=> setDetails(prev=>!prev)}>
                {details ? 'Hide Details' : "Show Details"}
                </button>
            <button className='py-2 px-4 border bg-red-400' onClick={DeleteUser}>Delete</button>
            </div>

            {details && <div>
                <p>username: {user.userName}</p>
                <p>Id: <span style={{fontWeight:'bold'}}>{user.id.toString()}</span></p>
                </div>}
        </div>
    )

    async function DeleteUser(){
        console.log(user.id)
        await axios.delete<IUser>(`http://localhost:5000/admin/users/${user.id}`)

        window.location.reload()
    }
}