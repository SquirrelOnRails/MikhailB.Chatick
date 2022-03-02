import {configureStore} from '@reduxjs/toolkit';
import thunk from 'redux-thunk';
import token from './slices/tokenSlice';
import user from './slices/userSlice';

export default configureStore({
  reducer: {
    user,
    token,
  },
  middleware: [thunk],
});
