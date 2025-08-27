<script lang="ts" setup>
import { getAccessToken, signIn } from '@/services/auth';
import { ref } from 'vue';

const model = ref(null);
const items = ref<any[]>([]);
const searchInput = ref('');

const login = async () => {
  await signIn();
};

const searchGame = async (query: string) => {
  if (query.length < 3) {
    items.value = [];
    return;
  }

  const token = await getAccessToken();
  if (!token) {
    console.error('No access token available');
    return;
  }

  const response = await fetch('/gateway/igdb/v4/games', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Client-ID': '--',
      Authorization: `Bearer ${token}`,
    },
    body: `search "${query}"; fields name; limit 5;`,
  });

  const games = await response.json();
  items.value = games.map((g) => ({
    name: g.name,
    id: g.id,
  }));
};
</script>

<template>
  <v-autocomplete
    v-model="model"
    v-model:search="searchInput"
    :items="items"
    placeholder="Rechercher un jeu..."
    item-title="name"
    return-object
    hide-details
    no-filter
    @update:search="searchGame"
  ></v-autocomplete>

  <v-btn @click="login">Login</v-btn>
</template>
