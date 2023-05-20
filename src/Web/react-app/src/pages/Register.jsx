import axios from '../axios'
import '../components/styles/auth.css'

const emailregex = new RegExp('[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}')

function Validate(email, password, repeatPassword){
    var err =''

    if (!email || !password || !repeatPassword) {
        err += 'Заполните все поля!'
        alert(err)
        return
    }

    if (!email.match(emailregex)) {
        err += 'Введите корректный E-Mail.\n'
    }
    if (password != repeatPassword) {
        err += 'Пароли не совпадают.\n'
    }
    if (password.length < 8) {
        err += 'Пароль должен состоять более чем из 8 символов.'
    } 
    if (err != '') {
        alert(err)
    }
    
    return err
}

function Reg() {
    var email = document.getElementById('email').value
    var password = document.getElementById('password').value
    var repeatPassword = document.getElementById('repeatPassword').value
    if (Validate(email, password, repeatPassword) != '') {
        return
    }

    axios.post('/auth/register', {email, password, repeatPassword}).then((res) => alert(res)).catch((e) => alert(e.response.data.errors))
}

function Register() {
    
    return (
        <div className="authContainer">
            <div className="baseContainer">
                <div className="authInnerContainer">
                    <span className='titleSpan'>Dekoffe</span>
                    <input type='email' placeholder='Имя пользователя' name='email' id='email'/>
                    <input type='password' placeholder='Пароль' name='password' id='password'/>
                    <input type='password' placeholder='Пароль(повторно)' name='repeatPassword' id='repeatPassword'/>
                    <div></div>
                    <button onClick={Reg}>Зарегестрироваться</button>
                </div>
            </div>
        </div>
    )
}

export {Register}