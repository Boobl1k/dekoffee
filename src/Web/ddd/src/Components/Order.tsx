import axios from 'axios'
import React, {useState} from 'react'
import { IOrder } from '../models'

interface OrderProps{
    order:IOrder
}

export function Order({order}: OrderProps){
    
    const [details, setDetails]= useState(false)

    const btnBgClassName=details?'bg-blue-400': 'bg-yellow-400'

    const btnClasses=['py-2 px-4 border',btnBgClassName]

    return (
        <div className="border py-2 px-4 rounded flex flex-col items-center mb-2">
            <p>Order №: {order.id.toString()}</p>
            <p className="font-bold">Executor name: {order.executorName}</p>
            <div className="flex justify-between">
            <button className={btnClasses.join(' ')} onClick={()=> setDetails(prev=>!prev)}>
                {details ? 'Hide Details' : "Show Details"}
                </button>
            </div>

            {details && <div>
                <p>Sum: {order.totalSum}</p>
                <p>Address: {order.fullAddress}</p>
                <p>Status: {order.status}</p>
                <p>Amount of products in order: {order.products.length}</p>
                </div>}
        </div>
    )
}

