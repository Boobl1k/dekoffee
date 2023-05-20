import {Guid} from "guid-typescript"

export interface IProduct{
    id: Guid
    title: string
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