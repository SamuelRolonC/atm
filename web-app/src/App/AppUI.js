import React from 'react';
import './App.css';
import { Route, Routes } from 'react-router-dom';
import { Home } from '../Home/Index';
import { Pin } from '../Pin';
import { CardError } from '../CardError';
import { OperationMenu } from '../OperationMenu';

function AppUI() {

  return (
    <div className='App'>
        <h1>ATM</h1>
        <Routes>    
            <Route path='/' element={<Home />} />
            <Route path='/Card' element={<Home />} />
            <Route path='/Card/Login/:id' element={<Pin />} />
            <Route path='/Card/Error' element={<CardError />} />
            <Route path='/Operation/Menu' element={<OperationMenu />} />
        </Routes>
    </div>
  );
}

export { AppUI };
