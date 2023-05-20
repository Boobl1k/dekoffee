import { Outlet } from 'react-router-dom';
import { Header } from './Header';
import { Footer } from './Footer';

const Layout = () => {
    return (
        <>
            <header>
                <Header />
            </header>
            
            <div className='page'>
                <Outlet />
            </div>

            <footer>
                <Footer />
            </footer>
        </>
    )
}

export {Layout}
