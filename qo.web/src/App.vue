<template>
  <div id="app" class="container mx-auto items-center h-screen">
    <div class="flex justify-center">
      <OfferHero
        :amount="amount"
        />
    </div>
  </div>
</template>

<script>
import OfferHero from './components/OfferHero'
import { Api } from './api'

export default {
  name: 'App',
  components: {
    OfferHero
  },
  data() {
    return {
      amount: null,
      includedPlayers: []
    }
  },
  async created() {
    try {
      let resp = await Api.qualifyingOffers.get()
      this.amount = resp.amount
      this.includedPlayers = resp.includedPlayers
    }
    catch(err) {
      console.log(err)
    }
  }
}
</script>

<style src="./assets/tailwind.css">