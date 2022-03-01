import {createSlice} from '@reduxjs/toolkit';
import IToken from '../../Interfaces/IToken';

const tokenStorageValue = localStorage.getItem('token');
let tokenStorageObj = null;
if (tokenStorageValue) {
  tokenStorageObj = JSON.parse(tokenStorageValue);
}

const tokenSlice = createSlice({
  name: 'token',
  initialState: {
    token: {
      value: (tokenStorageObj as IToken)?.Value ?? '',
      uid: (tokenStorageObj as IToken)?.UID ?? '',
    },
  },
  reducers: {
    setToken: (state, action) => {
      state.token = action.payload;
    },
  },
});

export const {setToken} = tokenSlice.actions;

export const selectToken = (state: any) => state.token;

export default tokenSlice.reducer;
