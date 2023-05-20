import axios from "axios";
import { Guid } from "guid-typescript";
import React, { useState } from "react";
import { IProduct } from "../models";
import { ErrorMessage } from "./ErrorMessage";

const productData: IProduct ={
    id: 'dqwdd' as unknown as Guid,
    title: '',
    price: 0.0,
    imageUrl: '',
    description: '',
    net: 0.0,
    country: '',
    gross: 0.0,
    energyValue: 0.0,
    isBlocked:false
}

interface CreateProductProps{
    onCreate:(product: IProduct)=>void
}

export function CreateProduct({onCreate}:CreateProductProps){
    const [title,setTitle]=useState('')
    const [price,setPrice]=useState(0)
    const [description,setDescription]=useState('')
    const [net,setNet]=useState(0)
    const [gross,setGross]=useState(0)
    const [counrty,setCountry]=useState('')
    const [energyValue,setEnergyValue]=useState(0)
    const [imageUrl,setImageUrl]=useState('')
    const [error,setError]=useState('')


    const sumbitHandler= async (event: React.FormEvent)=>{
        event.preventDefault()
        setError('')

        if (title.trim().length==0){
            setError('Please enter valid data')
            return
        }
        if (description.trim().length==0){
            setError('Please enter valid data')
            return
        }
        if (counrty.trim().length==0){
            setError('Please enter valid data')
            return
        }
        if (imageUrl.trim().length==0){
            setError('Please enter valid data')
            return
        }

    
        productData.title=title
        productData.price=price
        productData.description=description
        productData.country=counrty
        productData.energyValue=energyValue
        productData.gross=gross
        productData.isBlocked=false
        productData.net=net
        productData.imageUrl=imageUrl

        console.log(productData)
        const response =await axios.post<IProduct>('http://localhost:5000/admin/products',productData)

        onCreate(response.data)

        window.location.reload()
    }

    return(
        <form onSubmit={sumbitHandler}>
            <input type="text" className="border py-2 px-4 mb-2 w-full outline-0" placeholder="Enter product title..." value={title} onChange={event=>setTitle(event.target.value)} />
            <input type="text" className="border py-2 px-4 mb-2 w-full outline-0" placeholder="Enter product price" value={price} onChange={event=>setPrice(Number(event.target.value))} />
            <input type="text" className="border py-2 px-4 mb-2 w-full outline-0" placeholder="Enter product desc" value={description} onChange={event=>setDescription(event.target.value)} />
            <input type="text" className="border py-2 px-4 mb-2 w-full outline-0" placeholder="Enter product image" value={imageUrl} onChange={event=>setImageUrl(event.target.value)} />
            <input type="text" className="border py-2 px-4 mb-2 w-full outline-0" placeholder="Enter product net" value={net} onChange={event=>setNet(Number(event.target.value))} />
            <input type="text" className="border py-2 px-4 mb-2 w-full outline-0" placeholder="Enter product gross" value={gross} onChange={event=>setGross(Number(event.target.value))} />
            <input type="text" className="border py-2 px-4 mb-2 w-full outline-0" placeholder="Enter product country" value={counrty} onChange={event=>setCountry(event.target.value)} />
            <input type="text" className="border py-2 px-4 mb-2 w-full outline-0" placeholder="Enter product energyValue" value={energyValue} onChange={event=>setEnergyValue(Number(event.target.value))} />
            <input type="hidden" name="isBlocked" value="false"></input>
            {error &&<ErrorMessage error={error}/>}
            <button className="py-2 px-4 border bg-yellow-400 hover:text-white">Create</button>
        </form>
    )
}