import {Route,Routes} from 'react-router-dom'
import { UsersPage } from './Pages/UsersPage';
import { ProductsPage } from './Pages/ProductsPage';
import {Navigation} from './Components/Navigation'

function App() {
    return(
      <>
      <Navigation/>
      <Routes>
        <Route path='/' element={<ProductsPage/>}></Route>
        <Route path='/users' element={<UsersPage/>}></Route>
      </Routes>
      </>
    )
}

export default App;
