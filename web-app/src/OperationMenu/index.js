import React from "react";
import './OperationMenu.css';
import { Link } from "react-router-dom";

function OperationMenu() {
    return (
        <div className='OperationMenu'>
            <span>Seleccione una operación</span>
            <button className="operationMenuButton" type="button">Retiro</button>
            <button className="operationMenuButton" type="button">Balance</button>
            <Link to="/">
                <button className="operationMenuButton" type="button">Salir</button>
            </Link>
        </div>
    );
}

export { OperationMenu };