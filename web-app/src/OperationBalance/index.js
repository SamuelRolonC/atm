import React, { useCallback } from "react";
import { Link } from "react-router-dom";
import { useParams } from "react-router-dom";
import { cardFormat } from "../Helpers/utils";

function OperationBalance() {
    const { id } = useParams();

    const [ balanceData, setBalanceData ] = React.useState({});

    const urlOperationMenu = "/Operation/Menu/" + id;

    const getBalanceData = useCallback(async () => {
        try {
            const url = 'https://localhost:44343/Operation/Balance?id=' + id;
            fetch(url, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                },
            })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    console.log('Success');
                    console.log(data);

                    let formatting_options = {
                        style: 'currency',
                        currency: 'ARS',
                        minimumFractionDigits: 2,
                    }
                    let numberFormat = new Intl.NumberFormat('es-ES', formatting_options );
                    
                    setBalanceData({
                        cardNumber: cardFormat(data.cardNumber),
                        cardDueDate: data.cardDueDate,
                        cardBalance: numberFormat.format(data.cardBalance)
                    });
                }
                else {
                    console.log('Error: ', data);
                    alert('Error: ' + data.message);
                }
            })
            .catch((error) => {
                console.error('Error:', error);
            });
        } catch(error) {
            console.error(error);
        }
    }, [id]);

    React.useEffect(() => {
        getBalanceData();
    }, [getBalanceData]);

    return (
        <div className='OperationBalance'>
            <Link to={urlOperationMenu}>
                <button className="operationMenuButton" type="button">Atras</button>
            </Link>
            <Link to="/">
                <button className="operationMenuButton" type="button">Salir</button>
            </Link>
            <span>Número: {balanceData.cardNumber}</span>
            <span>Vencimiento : {balanceData.cardDueDate}</span>
            <span>Balance: {balanceData.cardBalance}</span>
        </div>
    );
}

export { OperationBalance };