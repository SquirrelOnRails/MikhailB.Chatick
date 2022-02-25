import React from 'react';
import {Badge, Container} from 'react-bootstrap';
import Logout from '../Logout/Logout';
import './Header.css';

export const Header = () => {
  return (
    <header>
      <Container className="col-md-12 d-flex justify-content-md-between">
        <h1 className="app-name">Chat Application</h1>
        <div>
          <Logout />
          <Badge pill bg="light" text="dark">
            Username
          </Badge>
        </div>
      </Container>
    </header>
  );
};
