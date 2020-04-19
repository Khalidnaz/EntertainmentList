<template>
	<v-container>
		<!-- load list of movies -->
	</v-container>
</template>

<script>
import { mapGetters } from 'vuex';
export default {
	name: 'Home',
	computed: {
    ...mapGetters(['user']),
  },
	created() {
		if (!this.user) {
			this.$router.push('/login')
		}

		// dispatch action to get movies
	}
}
</script>