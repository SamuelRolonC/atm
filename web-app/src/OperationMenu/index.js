import React from "react";
import './OperationMenu.css';
import { Link } from "react-router-dom";
import { useParams } from "react-router-dom";

function OperationMenu() {
    const { id } = useParams();

    const urlBalance = "/Operation/Balance/" + id;

    return (
        <div className='OperationMenu'>
            <span>Seleccione una operación</span>
            <button className="operationMenuButton" type="button">Retiro</button>
            <Link to={urlBalance}>
                <button className="operationMenuButton" type="button">Balance</button>
            </Link>
            <Link to="/">
                <button className="operationMenuButton" type="button">Salir</button>
            </Link>
        </div>
    );
}

export { OperationMenu };