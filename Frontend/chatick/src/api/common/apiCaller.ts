import axios from 'axios';
import Settings from '../../Settings/Settings';

const enum Methods {
  GET = 'get',
  POST = 'post',
  PUT = 'put',
  DELETE = 'delete',
}
interface IRequestParams {
  method: Methods;
  url: string;
  params: object;
  data: object;
}

const performRequest = async (args: IRequestParams) => {
  const tokenStr = localStorage.getItem('token');
  let token = null;
  if (tokenStr && tokenStr !== 'undefined') {
    token = JSON.parse(tokenStr);
  }

  let response;
  try {
    response = await axios.request({
      method: args.method,
      url: `https://${Settings.server.https.host}:${
        Settings.server.https.port ?? 80
      }/${args.url}`,
      data: args.data,
      params: args.params,
      headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'GET, PUT, POST, DELETE',
        Authorization: token?.value ? `Bearer ${token.value}` : '',
      },
    });
    return response.data;
  } catch (err) {
    console.log(
      'Error while performing http request',
      `method: ${args.method}`,
      `url: ${args.url}`,
      err
    );
    throw err;
  }
};

export const GET = async (url: string, payload: Object = new Object()) => {
  return performRequest({
    method: Methods.GET,
    url: url,
    params: payload,
    data: new Object(),
  });
};

export const POST = async (url: string, payload: Object = new Object()) => {
  return performRequest({
    method: Methods.POST,
    url: url,
    params: new Object(),
    data: payload,
  });
};

export const PUT = async (url: string, payload: Object = new Object()) => {
  return performRequest({
    method: Methods.PUT,
    url: url,
    params: new Object(),
    data: payload,
  });
};

export const DELETE = async (url: string, payload: Object = new Object()) => {
  return performRequest({
    method: Methods.DELETE,
    url: url,
    params: payload,
    data: new Object(),
  });
};
