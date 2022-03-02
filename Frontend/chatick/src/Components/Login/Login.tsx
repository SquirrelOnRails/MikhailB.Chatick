import React, {useState} from 'react';
import IToken from '../../Interfaces/IToken';
import {useNavigate} from 'react-router-dom';
import {POST} from '../../api/common/apiCaller';
import './style.css';
import {Button, Container, Form} from 'react-bootstrap';
import {useDispatch} from 'react-redux';

interface ILoginUser {
  emailCred: string;
  passwordCred: string;
}
const loginUser = async ({
  emailCred,
  passwordCred,
}: ILoginUser): Promise<IToken> => {
  return POST(
    'api/auth/login',
    JSON.stringify({email: emailCred, password: passwordCred})
  )
    .then(data => data.token) // TODO обработать отсутствие тела
    .catch(err => {
      console.log(err);
      alert(err); // TODO обработать
    });
};

interface ILogin {
  setToken: (token: IToken) => void;
}
export const Login: React.FC<ILogin> = ({setToken}) => {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const [email, setEmail] = useState<string>('');
  const [password, setPassword] = useState<string>('');

  const onLoginSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const tokenData = await loginUser({
      emailCred: email,
      passwordCred: password,
    });
    if (tokenData?.value) {
      localStorage.setItem('token', JSON.stringify(tokenData));
      dispatch(setToken(tokenData));
      navigate('/');
    }
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
