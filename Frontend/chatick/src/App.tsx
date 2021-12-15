import React, { useState } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Dashboard from './Components/Dashboard/Dashboard';
import Login from './Components/Login/Login';

import './App.css';

export const App = () => {
  const [token, setToken] = useState<string>('');

  if (!token) {
    return <Login setToken={setToken} />;
  }

  return (
    <div className="App">
      <h1>Application</h1>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Login setToken={setToken}/>} />
          <Route path="/dashboard" element={<Dashboard/>} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}
