import React,{ useContext, useState } from 'react';
import { CreateProduct } from '../Components/CreateProduct';
import { ErrorMessage } from '../Components/ErrorMessage';
import { Loader } from '../Components/Loader';
import { Modal } from '../Components/Modal';
import { Product } from '../Components/Product'
import { ModalContext } from '../context/ModalContext';
import {useProducts} from '../hooks/products'
import { IProduct } from '../models';

export function ProductsPage(){
    const{loading,error,products,addProduct}=useProducts()
  
  const{modal,open,close}=useContext(ModalContext)

  const CreateHandler=(product:IProduct)=>{
    close()
    addProduct(product)


  }

  return(
    <div className="container mx-auto max-w-2xl pt-5">
      {loading&& <Loader/>}
      {error && <ErrorMessage error={error}/>}
      <button className='fixed bottom-5 right-5 rounded-full bg-red-700 text-white text-2xl px-4 py-2' onClick={open}>+</button>
      {products.map(product=><Product product={product} key={product.id.toString()}/>)}
      {modal &&<Modal title='Create new product' onClose={close}>
        <CreateProduct onCreate={close}/>
      </Modal>}
    </div> 
  )
}