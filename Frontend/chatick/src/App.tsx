import { BrowserRouter, Route, Routes, Navigate } from 'react-router-dom';
import './App.css';
import Dashboard from './Components/Dashboard/Dashboard';
import Register from './Components/Register/Register';
import Login from './Components/Login/Login';
import useToken from './Hooks/useToken';

export const App = () => {
  const { token, setToken } = useToken();

  return (
    <div className="App">
      <h1>Application</h1>
      <BrowserRouter>
        <Routes>
          {!token && <>
            <Route path="/register" element={<Register setToken={setToken} />} />
            <Route path="/login" element={<Login setToken={setToken}/>} />
            <Route path="*" element={<Navigate to="/login" />} />
          </>} 
          {token && <>
            <Route path="/" element={<Dashboard/>} /> {/* todo */}
            <Route path="/dashboard" element={<Dashboard/>} />
            <Route path="*" element={<Navigate to="/" />} />
          </>}
        </Routes>
      </BrowserRouter>
    </div>
  );
}
