import { AnonymousAuthenticationProvider } from '@microsoft/kiota-abstractions';
import { FetchRequestAdapter } from '@microsoft/kiota-http-fetchlibrary';
import { createApiClient } from '../clients/apiClients/apiClient';

// API requires no authentication, so use the anonymous
// authentication provider
const authProvider = new AnonymousAuthenticationProvider();

// Create request adapter using the fetch-based implementation
const adapter = new FetchRequestAdapter(authProvider);

const createClient = () => {
  return createApiClient(adapter);
};

export { createClient };
