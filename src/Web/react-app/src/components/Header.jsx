import { Link } from 'react-router-dom';
import './styles/header.css'

function Header () {
    return (
        <>
            <Link to="/" className='logo'>Dekoffe</Link>
            <Link to="/err11" className='profile'>Home</Link>
        </>
    )
}

export {Header}
