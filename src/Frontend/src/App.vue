<script setup lang="ts">
import { RouterView, useRouter } from 'vue-router';

const router = useRouter();
function goHome() {
  router.push({ name: 'home' });
}
</script>

<template>
  <v-layout class="rounded rounded-md border">
    <v-app-bar>
      <v-app-bar-title
        ><RouterLink to="/" class="text-decoration-none"
          >One Game One Year</RouterLink
        ></v-app-bar-title
      >
    </v-app-bar>

    <v-main class="d-flex align-center justify-center">
      <v-container><RouterView /></v-container>
    </v-main>
  </v-layout>
</template>

<style scoped></style>
