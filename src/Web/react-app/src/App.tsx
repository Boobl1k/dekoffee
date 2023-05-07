import React from 'react';
import './App.css';
import axios from "./axios";

function App() {
    const alertFromFetch = () => {
        axios.get('catalog').then((x) => alert(x.status))
    }

    return (
        <div className="App">
            <header className="App-header" onClick={alertFromFetch}>
            </header>
        </div>
    );
}

export default App;
