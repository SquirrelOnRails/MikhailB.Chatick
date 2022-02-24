import React, {useState} from 'react';
import Settings from '../../Settings/Settings';
import IToken from '../../Interfaces/IToken';
import {useNavigate} from 'react-router-dom';
import './style.css';
import {Button, Container, Form} from 'react-bootstrap';

interface ILoginUser {
  emailCred: string;
  passwordCred: string;
}
const loginUser = async ({emailCred, passwordCred}: ILoginUser) => {
  //let token:IToken = { Value: "test123", ValidTo: new Date("2012.12.12"), UID: "FAKEUID" };
  //return token;

  // axios
  return fetch(
    `http://${Settings.server.http.host}:${Settings.server.http.port}}/api/auth/login`,
    {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({email: emailCred, password: passwordCred}),
    }
  ).then(data => data.json());
};

interface ILogin {
  setToken: (token: IToken) => void;
}
const Login: React.FC<ILogin> = ({setToken}) => {
  const navigate = useNavigate();

  const [email, setEmail] = useState<string>('');
  const [password, setPassword] = useState<string>('');

  const onLoginSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const tokenData = await loginUser({
      emailCred: email,
      passwordCred: password,
    });
    setToken(tokenData);
    navigate('/');
  };

  const handleRegister = () => {
    navigate('/register');
  };

  return (
    <Container className="col-sm-8 col-lg-4 justify-content-md-center">
      <Form onSubmit={onLoginSubmit}>
        <Form.Group className="mb-3" controlId="formBasicEmail">
          <Form.Label>Email address</Form.Label>
          <Form.Control
            type="email"
            placeholder="Enter email"
            onChange={e => setEmail(e.target.value)}
          />
        </Form.Group>

        <Form.Group className="mb-3" controlId="formBasicPassword">
          <Form.Label>Password</Form.Label>
          <Form.Control
            type="password"
            placeholder="Password"
            onChange={e => setPassword(e.target.value)}
          />
        </Form.Group>

        <Button variant="primary" type="submit">
          Submit
        </Button>

        <Button variant="link" type="button" onClick={handleRegister}>
          Register new account
        </Button>
      </Form>
    </Container>
  );
};

export default Login;
