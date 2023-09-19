import React from "react";
import { Link } from "react-router-dom";
import './CardError.css';

function CardError() {
    return (
        <div className='CardError'>
            <Link to="/">
                <button type="button">
                    Inicio
                </button>
            </Link>
            <span id="errorLabel">Los datos de la tarjeta no son válidos.</span>
        </div>
    );
}

export { CardError };