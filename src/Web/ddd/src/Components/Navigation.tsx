import React from "react"
import { Link } from "react-router-dom"

export function Navigation(){
    return(
        <nav className="h-[50px] flex justify-between px-5 bg-gray-500 text-white">
            <span>Product App</span>
            <span>
                <Link to="/admin" className="mr-2">Products</Link>
                <Link to="/admin/users" className="mr-2">Users</Link>
                <Link to="/admin/orders" className="mr-2">Orders</Link>
            </span>
        </nav>
    )
}