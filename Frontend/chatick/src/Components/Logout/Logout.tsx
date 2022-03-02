import React from 'react';
import {Button} from 'react-bootstrap';
import {useDispatch} from 'react-redux';
import {useNavigate} from 'react-router-dom';
import {setToken} from '../../store/slices/tokenSlice';

const Logout = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const handleLogOut = () => {
    dispatch(setToken(null));
    localStorage.removeItem('token');
    navigate('/login');
  };

  return (
    <Button variant="link" onClick={handleLogOut}>
      Logout
    </Button>
  );
};

export default Logout;
