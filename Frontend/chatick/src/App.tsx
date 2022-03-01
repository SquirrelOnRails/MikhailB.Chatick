import React, {useEffect} from 'react';
import {BrowserRouter, Route, Routes, Navigate} from 'react-router-dom';
import './App.css';
import {Dashboard} from './Components/Dashboard/Dashboard';
import {Register} from './Components/Register/Register';
import {Login} from './Components/Login/Login';
import {Header} from './Components/Header/Header';
import {Container} from 'react-bootstrap';
import {useDispatch, useSelector} from 'react-redux';
import {selectToken, setToken} from './store/slices/tokenSlice';

export const App = () => {
  const dispatch = useDispatch();
  const {token} = useSelector(selectToken);

  useEffect(() => {
    const authData = localStorage.getItem('token');

    console.log('store', token);
    console.log('local', authData);

    if (authData) {
      dispatch(setToken(authData));
    } else {
      dispatch(setToken(null));
    }
  }, []);

  return (
    <Container className="App col-md-8 d-flex flex-column justify-content-md-center ">
      <BrowserRouter>
        <Header />
        <Routes>
          {!token?.value && (
            <>
              <Route
                path="/register"
                element={<Register setToken={setToken} />}
              />
              <Route path="/login" element={<Login setToken={setToken} />} />
              <Route path="*" element={<Navigate to="/login" />} />
            </>
          )}
          {token?.value && (
            <>
              <Route path="/" element={<Dashboard />} /> {/* todo */}
              <Route path="/dashboard" element={<Dashboard />} />
              <Route path="*" element={<Navigate to="/" />} />
            </>
          )}
        </Routes>
      </BrowserRouter>
    </Container>
  );
};
