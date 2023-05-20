import {Product} from './Product'
import './styles/menu.css';

function Menu (props) {
    if (props?.products) {
        return (
            <div className="menu">
                <div>
                    <span className="titleSpan">Menu</span>
                </div>
                <div className="menuProducts">
                    {props.products.map(product => {
                        return (
                            <Product product = {product} callback = {props.callback} />
                        )
                    })}
                </div>
            </div>
        )
    }
    else {
        return (
            <></>
        )
    }
}

export {Menu}
