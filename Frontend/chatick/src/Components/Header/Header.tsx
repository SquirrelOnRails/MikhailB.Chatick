import React, {useEffect, useState} from 'react';
import {Badge, Container} from 'react-bootstrap';
import {useSelector} from 'react-redux';
import {GET} from '../../api/common/apiCaller';
import {selectToken} from '../../store/slices/tokenSlice';
import Logout from '../Logout/Logout';
import './Header.css';

export const Header = () => {
  const {token} = useSelector(selectToken);
  const [username, setUsername] = useState<string>();

  const getUsername = async () => {
    if (token?.uid) {
      const payload = {userId: token.uid};
      return GET('api/user/getdisplayinfo', payload)
        .then(data => {
          if (data.firstname && data.lastname) {
            setUsername(`${data.firstname} ${data.lastname}`);
          } else {
            setUsername('My account');
          }
        })
        .catch(err => {
          console.log(err); // TODO
          setUsername('Unavailable');
        });
    } else {
      return 'Anonymous';
    }
  };

  useEffect(() => {
    getUsername();
  }, [token]);

  return (
    <header>
      <Container className="col-md-12 d-flex justify-content-md-between">
        <h1 className="app-name">Chat Application</h1>
        {token?.value && (
          <div>
            <Logout />
            <Badge pill bg="light" text="dark">
              {username}
            </Badge>
          </div>
        )}
      </Container>
    </header>
  );
};
