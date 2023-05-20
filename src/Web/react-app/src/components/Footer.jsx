import { Link } from "react-router-dom"
import './styles/footer.css';

function Footer () {
    return (
        <>
            <div className="footerLinks">
                <Link to="https://t.me/tox1cman" className="underline">Дмитрий (Telegram)</Link>
                <Link to="https://t.me/shinraqwe" className="underline">Руслан (Telegram)</Link>
                <Link to="https://t.me/focusforever1" className="underline">Адель (Telegram)</Link>
                <Link to="https://t.me/Niiiliiiliii" className="underline">Мансур (Telegram)</Link>
            </div>
            <div className="footerInfo">
                Anti Consumer Society Club 
                <br />
                +7 (999) 831 31-22
            </div>
        </>
    )
}

export {Footer}
