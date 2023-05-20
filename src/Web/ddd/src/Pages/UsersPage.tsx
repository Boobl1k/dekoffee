import React,{ useContext, useState } from 'react';
import { CreateProduct } from '../Components/CreateProduct';
import { ErrorMessage } from '../Components/ErrorMessage';
import { Loader } from '../Components/Loader';
import { Modal } from '../Components/Modal';
import { Product } from '../Components/Product'
import { User } from '../Components/User';
import { ModalContext } from '../context/ModalContext';
import {useProducts} from '../hooks/products'
import { useUsers } from '../hooks/users';
import { IUser } from '../models';

export function UsersPage(){
    const{loading,error,users,addProduct}=useUsers()
  


  return(
    <div className="container mx-auto max-w-2xl pt-5">
      {loading&& <Loader/>}
      {error && <ErrorMessage error={error}/>}
      {users.map(user=><User user={user} key={user.id.toString()}/>)}
    </div> 
  )
}