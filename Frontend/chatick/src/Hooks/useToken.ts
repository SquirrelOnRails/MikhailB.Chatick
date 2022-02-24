import {useState} from 'react';
import IToken from '../Interfaces/IToken';

const useToken = () => {
  const getToken = () => {
    const tokenString = localStorage.getItem('token');
    if (!tokenString) {
      return null;
    }
    const userToken: IToken = JSON.parse(tokenString);
    return userToken;
  };

  const [token, setToken] = useState(getToken());

  const saveToken = (userToken: IToken) => {
    localStorage.setItem('token', JSON.stringify(userToken));
    setToken(userToken);
  };

  return {
    setToken: saveToken,
    token,
  };
};

export default useToken;
