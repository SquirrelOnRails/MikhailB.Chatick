import React from 'react';
import {Button} from 'react-bootstrap';
import {useNavigate} from 'react-router-dom';

const Logout = () => {
  const navigate = useNavigate();

  const handleLogOut = () => {
    localStorage.setItem('token', '');
    localStorage.clear();
    navigate('/login');
  };

  return (
    <Button variant="link" onClick={handleLogOut}>
      Logout
    </Button>
  );
};

export default Logout;
