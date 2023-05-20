import {Route,Routes} from 'react-router-dom'
import { UsersPage } from './Pages/UsersPage';
import { ProductsPage } from './Pages/ProductsPage';
import {Navigation} from './Components/Navigation'
import { OrdersPage } from './Pages/OrdersPage';

function App() {
    return(
      <>
      <Navigation/>
      <Routes>
        <Route path='/admin' element={<ProductsPage/>}></Route>
        <Route path='/admin/users' element={<UsersPage/>}></Route>
        <Route path='/admin/orders' element={<OrdersPage/>}></Route>
      </Routes>
      </>
    )
}

export default App;
