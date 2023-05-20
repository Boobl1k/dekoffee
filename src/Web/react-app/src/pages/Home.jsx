import { useEffect, useMemo, useState } from 'react'
import { Menu } from '../components/Menu'
import { Preview } from '../components/Preview'
import '../components/styles/home.css'
import axios from '../axios'

function Home() {
    const [onPreview, setOnPreview] = useState({})
    const [products, setProducts] = useState([])
    
    function setPreview(product){
        setOnPreview(product)
    };

    useEffect(() => {
        axios.get('/catalog').then((response) => {
            setProducts(response.data)
        })
    },[])
    return (
        <div className="home">
            <div className="baseContainer">
                <Preview product = {onPreview}/>
            </div>
            <div className="baseContainer">
                <Menu products = {products} callback = {setPreview}/>
            </div>
        </div>
    )
}

export {Home}