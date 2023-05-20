import './styles/product.css';

function CartProduct (props) {
    return (
        <div className="productContainer">
            <div className="productImage" style={{backgroundImage:`url("${props?.product.imageUrl}"`}}></div>
            <div className='productInfo'>
                <div className="productName">
                    {props?.product.title}
                </div>
                <div className="productPrice">
                    <b>{props?.product.price}₽</b>
                </div>
            </div>
        </div>
    )
}

export {CartProduct}
