import React from 'react';
import './InputAndKeyboard.css';
import { useNavigate } from 'react-router-dom';

function InputAndKeyboard(props) {
    const [inputValue, setInputValue] = React.useState('');
    const navigate = useNavigate();

    const isValidInputValue = props.item.isValidInputValue;
    const getObfuscatedValue = props.item.getObfuscatedValue;
    const getBody = props.item.getBody;
    const getNavigateOnSuccess = props.item.getNavigateOnSuccess;
    const getNavigateOnError = props.item.getNavigateOnError;
    const applyFormat = props.item.applyFormat;

    const inputType = props.item.inputType;

    const onSubmit = (event) => {
        event.preventDefault();

        const isValid = isValidInputValue(inputValue);
        if (!isValid) {
            onClearInputValueClick();
            alert('El valor es inválido');
            return;
        }

        setInputValue(getObfuscatedValue(props.item.format));

        const body = getBody(inputValue);

        fetch(props.item.urlToSubmit, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: body,
        })
        .then(response => response.json())
        .then(data => {
            if (data.isValid) {
                console.log('Success');
                let navigateTo = getNavigateOnSuccess(data);
                if (navigateTo)
                    navigate(navigateTo);
            }
            else {
                console.log('Error: ', data);
                let navigateTo = getNavigateOnError(data);
                if (navigateTo)
                    navigate(navigateTo);
            }
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    }

    const onChangeInputValue = (event) => {
        setInputValue(event.target.value);
    }

    const onNumericKeyboardClick = (event) => {
        if (!isValidInputValue(inputValue, true)) return;

        setInputValue(inputValue + event.target.textContent);
    }

    const onClearInputValueClick = () => {
        setInputValue('');
    }

    return(
        <div id="InputAndKeyboard">
            <form onSubmit={onSubmit}>
                <div id="inputValueContainer">
                    <input type={inputType} 
                        name="inputValue" 
                        value={applyFormat(inputValue)}
                        onChange={onChangeInputValue} 
                        disabled={true} />
                    <button 
                        type="button" 
                        className='clearInputValueButton'
                        onClick={onClearInputValueClick}>Limpiar</button>
                    { props.item.showLabel && 
                        <span id="inputValueLabel">{props.item.labelText}</span>
                    }
                </div>
                <div id="numericKeyboard" style={{margin: "10px"}}>
                    <div id="numericKeyboardRow1">
                        <button 
                            type="button" 
                            onClick={onNumericKeyboardClick}>1</button>
                        <button 
                            type="button"
                            onClick={onNumericKeyboardClick}>2</button>
                        <button type="button"
                            onClick={onNumericKeyboardClick}>3</button>
                    </div>
                    <div id="numericKeyboardRow2">
                        <button type="button"
                            onClick={onNumericKeyboardClick}>4</button>
                        <button type="button"
                            onClick={onNumericKeyboardClick}>5</button>
                        <button type="button"
                            onClick={onNumericKeyboardClick}>6</button>
                    </div>
                    <div id="numericKeyboardRow3">
                        <button type="button"
                            onClick={onNumericKeyboardClick}>7</button>
                        <button type="button"
                            onClick={onNumericKeyboardClick}>8</button>
                        <button type="button"
                            onClick={onNumericKeyboardClick}>9</button>
                    </div>
                    <div id="numericKeyboardRow4">
                        <button type="button"
                            onClick={onNumericKeyboardClick}>0</button>
                    </div>
                </div>
                <button 
                    type="submit" 
                    className='submitButton'>Aceptar</button>
            </form>
        </div>
    );
}

export { InputAndKeyboard };