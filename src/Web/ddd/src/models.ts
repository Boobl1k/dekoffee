import {Guid} from "guid-typescript"

export interface IProduct{
    id: Guid
    title: string
    imageUrl:string
    price: number
    description?: string
    net: number
    gross: number
    country: string
    energyValue:number
    isBlocked:boolean
}

export interface IUser{
    id: Guid
    email:string
    userName: string
    isDeleted: boolean
    isBlocked:boolean
}

export interface IOrder{
    id: Guid
    fullAddress: string
    executorName:string
    creationTime: Date 
    totalSum: number
    status: string
    products : IProduct[]
}