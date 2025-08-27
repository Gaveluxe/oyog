import { type OidcClientSettings, UserManager, WebStorageStateStore } from 'oidc-client-ts';

const twitchConfig: OidcClientSettings = {
  authority: 'https://id.twitch.tv/oauth2',
  client_id: 'xu3v9makgwuw5zlrujbswfd33g6pur',
  redirect_uri: window.location.origin + '/auth',
  response_type: 'token',
  stateStore: new WebStorageStateStore({ store: window.localStorage }),
};

export const userManager = new UserManager(twitchConfig);

export const signIn = async () => {
  try {
    await userManager.signinPopup();
  } catch (error) {
    console.error('Error during sign-in:', error);
  }
};

export const getAccessToken = async (): Promise<string | null> => {
  const user = await userManager.getUser();
  if (user && !user.expired) {
    return user.access_token;
  }
  return null;
};

export const isLoggedIn = async (): Promise<boolean> => {
  const user = await userManager.getUser();
  return !!user && !user.expired;
};
