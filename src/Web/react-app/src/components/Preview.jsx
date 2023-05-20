import { Link } from "react-router-dom"
import './styles/preview.css';

function Preview (props) {
    if (props?.product?.title)
    {
        return (
            <div className="preview">
                <div className="previewMainInfo">
                    <span className="previewProductName">
                        {props.product.title}
                    </span>
                    <span className="previewProductPrice">
                    {props.product.price}₽
                    </span>
                </div>
                <div className="previewProductImage" style={{backgroundImage:`url("${props.product.imageUrl}"`}}></div>
                <span className="previewProductDescription">
                        {props.product.description}
                </span>
                
                <div className="previewSecondaryInfo">
                    <span>
                        <b>Энергетическая ценность:</b> {props.product.energyValue} ккал
                    </span>
                    <span>
                        <b>Производитель зерна:</b> {props.product.country}
                    </span>
                    <span>
                        <b>Объём:</b> {props.product.net}мл
                    </span>
                </div>
                <div className="previewCartButtons">
                    <button className="addToCart">добавить в корзину</button>
                </div>
            </div>  
        )
    }
    else {
        return(
        <></>
        )
    }
}

export {Preview}
