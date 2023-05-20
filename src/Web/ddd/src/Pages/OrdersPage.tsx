import React,{ useContext, useState } from 'react';
import { CreateProduct } from '../Components/CreateProduct';
import { ErrorMessage } from '../Components/ErrorMessage';
import { Loader } from '../Components/Loader';
import { Modal } from '../Components/Modal';
import { Product } from '../Components/Product'
import { User } from '../Components/User';
import { ModalContext } from '../context/ModalContext';
import {useProducts} from '../hooks/products'
import { useOrders } from '../hooks/orders';
import { IOrder } from '../models';
import { Order } from '../Components/Order';

export function OrdersPage(){
    const{loading,error,orders,addOrder}=useOrders()
  


  return(
    <div className="container mx-auto max-w-2xl pt-5">
      {loading&& <Loader/>}
      {error && <ErrorMessage error={error}/>}
      {orders.map(order=><Order order={order} key={order.id.toString()}/>)}
    </div> 
  )
}