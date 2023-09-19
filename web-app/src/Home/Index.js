import React from 'react';
import './Home.css';
import { InputAndKeyboard } from '../InputAndKeyboard';
import { cardFormat } from '../Helpers/utils';

function Home() {
    
    const isValidInputValue = (inputValue, onEditing = false) => {
        const maxLength = 16;
        return (!onEditing && inputValue.length === maxLength) || (onEditing && inputValue.length < maxLength);
    }

    const getObfuscatedValue = () => {
        return '**** **** **** ****';
    }

    const getBody = (inputValue) => {
        const body = JSON.stringify({
            number: inputValue.replace(/\s/g, ''),
        });
        return body;
    }

    const getNavigateOnSuccess = (data) => {
        return '/Card/Login/' + data.cardId;
    }

    const getNavigateOnError = (data) => {
        return '/Card/Error';
    }

    const applyFormat = (value) => {
        return cardFormat(value);
    }

    const inputAndKeyboardItem = {
        format: 'card',
        urlToSubmit: 'https://localhost:44343/Home/CardNumber',
        showLabel: true,
        labelText: 'El número de tarjeta debe tener 16 dígitos',
        inputType: 'text',
        isValidInputValue: isValidInputValue,
        getObfuscatedValue: getObfuscatedValue,
        getBody: getBody,
        getNavigateOnSuccess: getNavigateOnSuccess,
        getNavigateOnError: getNavigateOnError,
        applyFormat: applyFormat
    };


    return(
        <div id="home">
            <span>Ingrese su número de tarjeta</span>
            <InputAndKeyboard item={inputAndKeyboardItem}/>
        </div>
    );
}

export { Home };