import './styles/product.css';

function Product (props) {
    return (
        <div className="productContainer" onClick={() => props.callback(props.product)}>
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

export {Product}
