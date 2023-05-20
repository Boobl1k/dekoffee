import axios from '../axios'
import '../components/styles/auth.css'

function Log() {
    var username = document.getElementById('username').value
    var password = document.getElementById('password').value

    if (!username || !password) {
        return
    }

    const loginParams = new URLSearchParams();
    loginParams.append('username', username)
    loginParams.append('password', password)
    loginParams.append('grant_type', 'password')
    
    debugger
    axios.post('/auth/login', loginParams, {headers: {'content-type': 'application/x-www-form-urlencoded'}}).then((res) => console.log(res)).catch((e) => alert(e.response.data.errors))
}

function Login() {
    
    return (
        <div className="authContainer">
            <div className="baseContainer">
                <form action='http://localhost:5000/auth/login' className="authInnerContainer">
                    <span className='titleSpan'>Dekoffe</span>
                    <input type='email' placeholder='Имя пользователя' name='email' id='username'/>
                    <input type='password' placeholder='Пароль' name='password' id='password'/>
                    <div></div>
                    <button type='submit'>Войти</button>
                </form>
            </div>
        </div>
    )
}

export {Login}