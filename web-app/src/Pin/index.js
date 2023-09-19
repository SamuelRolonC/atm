import React from "react";
import { InputAndKeyboard } from "../InputAndKeyboard";
import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";

function Pin() {
    const { id } = useParams();

    const isValidInputValue = (inputValue, onEditing = false) => {
        const maxLength = 4;
        return (!onEditing && inputValue.length === maxLength) || (onEditing && inputValue.length < maxLength);
    }

    const getObfuscatedValue = () => {
        return '****';
    }

    const getBody = (inputValue) => {
        const body = JSON.stringify({
            id: id,
            pin: inputValue,
        });
        return body;
    }

    const getNavigateOnSuccess = (data) => {
        return '/Operation/Menu/' + data.cardId;
    }

    const getNavigateOnError = (data) => {
        return '/Card/Error';
    }

    const applyFormat = (value) => {
        return value;
    }

    const inputAndKeyboardItem = {
        format: 'pin',
        urlToSubmit: 'https://localhost:44343/Home/CardPin',
        showLabel: false,
        inputType: 'password',
        isValidInputValue: isValidInputValue,
        getObfuscatedValue: getObfuscatedValue,
        getBody: getBody,
        getNavigateOnSuccess: getNavigateOnSuccess,
        getNavigateOnError: getNavigateOnError,
        applyFormat: applyFormat
    };

    return (
        <div className='Pin'>
            <Link to="/">
                <button type="button">Inicio</button>
            </Link>
            <span>Ingrese su PIN</span>
            <InputAndKeyboard item={inputAndKeyboardItem}/>
        </div>
    );
}

export { Pin };