<script setup lang="ts">
import type { ChallengeResponse, GameResponse } from '@/clients/apiClients/models';
import { createClient } from '@/services/apiClientFactory';
import { onMounted, ref } from 'vue';

const props = defineProps<{
  id: string;
}>();

const loading = ref(false);
const gamesLoading = ref(false);

const client = createClient();
const challenge = ref<ChallengeResponse | undefined>(undefined);
const games = ref<GameResponse[] | undefined>(undefined);

onMounted(async () => {
  await loadChallenge();
  gamesLoading.value = true;
  loadGames();
  gamesLoading.value = false;
});

const loadChallenge = async () => {
  challenge.value = await client.api.challenges.byChallengeId(props.id).get();
};

const loadGames = async () => {
  loading.value = true;
  const games = await client.api.challenges.byChallengeId(props.id).games.get();
  loading.value = false;
};
</script>

<template>
  <h2>Challenge</h2>

  <v-container v-if="!loading">
    <div v-if="challenge">
      <h3>{{ challenge.username }} - {{ challenge.year }}</h3>

      <v-data-table :items="games" :loading="gamesLoading" hide-default-footer></v-data-table>
    </div>
    <div v-else>
      <p>No challenge found.</p>
    </div>
  </v-container>
</template>
