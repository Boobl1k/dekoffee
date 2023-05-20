import { useEffect, useMemo, useState } from 'react'
import { CartProduct } from '../components/CartProduct'
import { Preview } from '../components/Preview'
import '../components/styles/cart.css'
import axios from '../axios'

function Cart() {
    const [onPreview, setOnPreview] = useState({})
    const [products, setProducts] = useState([])
    
    function setPreview(product){
        setOnPreview(product)
    };

    useEffect(() => {
        axios.get('/cart').then((response) => {
            setProducts(response.data)
        })
    },[])
    return (
        <div className="cart">
            <div className="baseContainer">
                {products.map(product => {
                        return (
                            <CartProduct product = {product} />
                        )
                    })}
                
            </div>
            <div className="baseContainer">
                create order
            </div>
        </div>
    )
}

export {Cart}