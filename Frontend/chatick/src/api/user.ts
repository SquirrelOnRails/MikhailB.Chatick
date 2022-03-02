import {GET} from './common/apiCaller';

/**
 * Get user display info request
 * @returns user display info
 */
export const GetUserDisplayInfo = async (userId: string) => {
  return await GET('api/user/GetDisplayInfo', {userId: userId});
};
