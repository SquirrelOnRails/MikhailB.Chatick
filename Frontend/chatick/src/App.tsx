// import React, { useState } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import Dashboard from './Components/Dashboard/Dashboard';
import Login from './Components/Login/Login';
import useToken from './Hooks/useToken';

export const App = () => {
  const { token, setToken } = useToken();

  if (!token) {
    return <Login setToken={setToken} />;
  }

  return (
    <div className="App">
      <h1>Application</h1>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Dashboard/>} />
          <Route path="/dashboard" element={<Dashboard/>} />
          <Route path="/login" element={<Login setToken={setToken}/>} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}
