import axios from 'axios'
import React, {useState} from 'react'
import { IProduct } from '../models'

interface ProductProps{
    product: IProduct
}

export function Product({product}: ProductProps){
    
    const [details, setDetails]= useState(false)

    const btnBgClassName=details?'bg-blue-400': 'bg-yellow-400'

    const btnClasses=['py-2 px-4 border',btnBgClassName]

    return (
        <div className="border py-2 px-4 rounded flex flex-col items-center mb-2">
            <p>{product.title}</p>
            <p className="font-bold">{product.price}Р</p>
            <img src={product.imageUrl} className="w-1/6" alt={product.title}/>
            <br/>
            <div className="flex justify-between">
            <button className={btnClasses.join(' ')} onClick={()=> setDetails(prev=>!prev)}>
                {details ? 'Hide Details' : "Show Details"}
                </button>
            <button className='py-2 px-4 border bg-red-400' onClick={DeleteProduct}>Delete</button>
            </div>

            {details && <div>
                <p>{product.description}</p>
                <p>Net: <span style={{fontWeight:'bold'}}>{product.net}</span></p>
                <p>gross: <span style={{fontWeight:'bold'}}>{product.gross}</span></p>
                <p>Country: <span style={{fontWeight:'bold'}}>{product.country}</span></p>
                <p>Energy Value: <span style={{fontWeight:'bold'}}>{product.energyValue}</span></p>
                </div>}
        </div>
    )

    async function DeleteProduct(){
        await axios.delete<IProduct>(`http://localhost:5000/admin/products/${product.id}`)

        window.location.reload()
    }
}