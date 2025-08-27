<script lang="ts" setup>
import { userManager } from '@/services/auth';
import { onMounted, ref } from 'vue';

const error = ref<string | null>(null);

onMounted(async () => {
  try {
    const user = userManager.signinCallback();
    console.log('User signed in:', user);
    window.close();
  } catch (err) {
    console.error('Error during sign-in callback:', err);
    error.value = (err as Error).message;
  }
});
</script>

<template>
  <div>
    <p v-if="!error">Authentification en cours...</p>
    <p v-else>Erreur lors de l'authentification : {{ error }}</p>
  </div>
</template>
